import { removeClient } from "@/lib/clients/actions";
import { Client } from "@/lib/clients/types";
import { Icon } from "@iconify/react/dist/iconify.js";
import {
  Modal,
  ModalContent,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Button,
  useDisclosure,
} from "@nextui-org/react";
import { revalidatePath } from "next/cache";
import { useState } from "react";
import { toast } from "react-toastify";

export default function ConfirmationForm({ client }: { client: Client }) {
  const { isOpen, onOpen, onOpenChange } = useDisclosure();
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const onAccept = async () => {
    setIsLoading(true);
    removeClient(client);
    setIsLoading(false);
    toast.success("Your Client has been removed!");
    onOpenChange();
  };
  return (
    <>
      <Button onPress={onOpen} isIconOnly variant="light">
        <Icon
          className="text-red-600"
          icon="solar:trash-bin-minimalistic-2-outline"
          width="24"
          height="24"
        />
      </Button>
      <Modal isOpen={isOpen} onOpenChange={onOpenChange}>
        <ModalContent>
          {(onClose) => (
            <>
              <ModalBody className="flex w-full justify-center items-center mt-8">
                <span>Are you sure to remove this client?</span>
              </ModalBody>
              <ModalFooter>
                <Button color="danger" variant="light" onPress={onClose}>
                  Close
                </Button>
                <Button
                  color="secondary"
                  onPress={onAccept}
                  isLoading={isLoading}
                >
                  Remove
                </Button>
              </ModalFooter>
            </>
          )}
        </ModalContent>
      </Modal>
    </>
  );
}

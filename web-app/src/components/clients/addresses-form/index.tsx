import {
  Client,
  ClientAddress,
  ClientAddressSchema,
} from "@/lib/clients/types";
import { zodResolver } from "@hookform/resolvers/zod";
import { Icon } from "@iconify/react/dist/iconify.js";
import {
  Modal,
  ModalContent,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Button,
  useDisclosure,
  Input,
} from "@nextui-org/react";
import React, { useEffect } from "react";
import { Controller, useForm, useFormContext } from "react-hook-form";
import { toast } from "react-toastify";
import { z } from "zod";

export default function AddressForm({
  clientAddress,
  isOpen,
  onOpen,
  onOpenChange,
}: {
  clientAddress?: ClientAddress;
  isOpen: boolean;
  onOpen: () => void;
  onOpenChange: () => void;
}) {
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const clientForm = useFormContext();

  useEffect(() => {
    form.reset(clientAddress);
  }, [clientAddress]);
  const form = useForm<z.infer<typeof ClientAddressSchema>>({
    resolver: zodResolver(ClientAddressSchema),
    defaultValues: clientAddress ?? {
      street: "",
      city: "",
      zipCode: "",
    },
  });

  const onSubmit = async (values: z.infer<typeof ClientAddressSchema>) => {
    setIsLoading(true);
    let currentValues = clientForm.watch("addresses") as ClientAddress[];

    currentValues = currentValues.filter(
      (d) => d.street !== values.street && d.id !== values.id
    );
    clientForm.setValue("addresses", [...currentValues, values]);
    setIsLoading(false);
    toast.success("Your address has been saved!");
    onOpenChange();
  };

  const handleDelete = () => {
    let currentValues = clientForm.watch("addresses") as ClientAddress[];
    currentValues = currentValues.filter(
      (d) => d.street !== form.getValues("street")
    );
    clientForm.setValue("addresses", [...currentValues]);
    toast.success("Your address has been removed!");
    onOpenChange();
  };
  return (
    <>
      <Modal isOpen={isOpen} onOpenChange={onOpenChange}>
        <ModalContent className="p-4">
          {(onClose) => (
            <>
              <ModalHeader className="flex flex-col gap-1">
                Client Address
              </ModalHeader>
              <ModalBody>
                <form
                  className="justify-center items-center w-full space-y-3"
                  onSubmit={form.handleSubmit(onSubmit)}
                >
                  <div className="flex w-full space-x-4">
                    <Controller
                      name="street"
                      control={form.control}
                      render={({ field, fieldState }) => (
                        <Input
                          label="Street"
                          labelPlacement="outside"
                          placeholder="Av saint thomas #34, FL"
                          value={field.value}
                          onValueChange={field.onChange}
                          errorMessage={fieldState.error?.message}
                          isInvalid={!!fieldState.error}
                          startContent={
                            <Icon
                              icon="solar:card-outline"
                              className="text-foreground-400"
                              width="24"
                              height="24"
                            />
                          }
                        />
                      )}
                    />
                  </div>
                  <div className="flex w-full space-x-4">
                    <Controller
                      name="city"
                      control={form.control}
                      render={({ field, fieldState }) => (
                        <Input
                          label="City"
                          labelPlacement="outside"
                          placeholder="San Diego"
                          value={field.value}
                          onValueChange={field.onChange}
                          errorMessage={fieldState.error?.message}
                          isInvalid={!!fieldState.error}
                          startContent={
                            <Icon
                              icon="solar:card-outline"
                              className="text-foreground-400"
                              width="24"
                              height="24"
                            />
                          }
                        />
                      )}
                    />
                  </div>
                  <div className="flex w-full space-x-4">
                    <Controller
                      name="zipCode"
                      control={form.control}
                      render={({ field, fieldState }) => (
                        <Input
                          label="Zip code"
                          labelPlacement="outside"
                          placeholder="33123-1239"
                          value={field.value}
                          onValueChange={field.onChange}
                          errorMessage={fieldState.error?.message}
                          isInvalid={!!fieldState.error}
                          startContent={
                            <Icon
                              icon="solar:letter-outline"
                              className="text-foreground-400"
                              width="24"
                              height="24"
                            />
                          }
                        />
                      )}
                    />
                  </div>

                  <div className="flex w-full space-x-4 justify-end pt-4">
                    {clientAddress?.street && (
                      <Button
                        color="danger"
                        onPress={handleDelete}
                        variant="bordered"
                        startContent={
                          <Icon
                            icon="solar:trash-bin-minimalistic-2-outline"
                            width="18"
                            height="18"
                          />
                        }
                      >
                        Remove
                      </Button>
                    )}
                    <Button type="submit" color="secondary">
                      Save
                    </Button>
                  </div>
                </form>
              </ModalBody>
            </>
          )}
        </ModalContent>
      </Modal>
    </>
  );
}

"use client";
import React, { useState } from "react";
import {
  Form,
  Input,
  Select,
  SelectItem,
  Checkbox,
  Button,
  User,
  Card,
  CardBody,
  Textarea,
  Listbox,
  ListboxItem,
  ScrollShadow,
  useDisclosure,
} from "@nextui-org/react";
import { Icon } from "@iconify/react/dist/iconify.js";
import AddressForm from "../addresses-form";
import { useFormContext } from "react-hook-form";
import { ClientAddress } from "@/lib/clients/types";
export function AddressesList() {
  const { isOpen, onOpen, onOpenChange } = useDisclosure();
  const [currentAddress, setCurrentAddress] = useState<ClientAddress>();
  const form = useFormContext();

  const addresses = form.watch("addresses") as ClientAddress[];

  return (
    <Card className=" max-w-3xl p-4 max-h-[400px] col-span-4">
      <AddressForm
        clientAddress={currentAddress}
        isOpen={isOpen}
        onOpen={onOpen}
        onOpenChange={onOpenChange}
      />
      <CardBody>
        <div className="flex space-x-2 mb-6">
          <span className="text-2xl">Addresses</span>
          <Button
            onPress={() => {
              onOpen();
              setCurrentAddress({
                street: "",
                city: "",
                zipCode: "",
              });
            }}
            isIconOnly
          >
            <Icon icon="solar:add-circle-outline" width="24" height="24" />
          </Button>
        </div>
        <ScrollShadow
          hideScrollBar
          className="w-full flex"
          orientation="horizontal"
        >
          <Listbox
            className="p-0"
            aria-label="Clients address list"
            classNames={{
              list: "max-h-80 overflow-y-auto ",
            }}
          >
            {addresses.length > 0 ? (
              addresses.map((address) => (
                <ListboxItem
                  className="p-0"
                  onPress={() => {
                    onOpenChange();
                    setCurrentAddress(address);
                  }}
                  key={address.street}
                  variant="bordered"
                  textValue="Items"
                  as="button"
                >
                  <div className="flex w-full justify-between border border-foreground-100 rounded-lg p-4 items-center">
                    <div className="flex flex-col space-y-2 ">
                      <span className=" font-bold">{address.street}</span>
                      <span className="text-xs">
                        {" "}
                        {address.city}, {address.zipCode}
                      </span>
                    </div>
                    <Icon
                      icon="solar:circle-top-up-outline"
                      width="20"
                      height="20"
                      className="text-foreground-400"
                    />
                  </div>
                </ListboxItem>
              ))
            ) : (
              <></>
            )}
          </Listbox>
        </ScrollShadow>
      </CardBody>
    </Card>
  );
}

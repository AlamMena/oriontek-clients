"use client";
import React, { useEffect } from "react";
import {
  Input,
  Select,
  SelectItem,
  Checkbox,
  Button,
  User,
  Card,
  CardBody,
  Textarea,
  Alert,
  useDisclosure,
} from "@nextui-org/react";
import { Icon } from "@iconify/react/dist/iconify.js";
import { zodResolver } from "@hookform/resolvers/zod";
import { Controller, FormProvider, useForm } from "react-hook-form";
import { Client, ClientSchema } from "@/lib/clients/types";
import z from "zod";
import { saveClient } from "@/lib/clients/actions";
import { AddressesList } from "../addresses-list";
import { useRouter } from "next/navigation";

export function ClientForm({ client }: { client?: Client }) {
  const router = useRouter();
  const [isLoading, setIsLoading] = React.useState<boolean>(false);
  const [alertStatus, setAlertStatus] = React.useState<string>("");
  const [alertTitle, setAlertTitle] = React.useState<string>("");

  const form = useForm<z.infer<typeof ClientSchema>>({
    resolver: zodResolver(ClientSchema),
    defaultValues: {
      name: "",
      lastName: "",
      email: "",
      identification: "",
      phoneNumber: "",
      addresses: [],
    },
  });
  useEffect(() => {
    form.reset(client);
  }, [client]);

  const onSubmit = async (values: z.infer<typeof ClientSchema>) => {
    setIsLoading(true);
    const response = await saveClient(values as Client);
    setIsLoading(false);
    if (response.errorMessage) {
      setAlertStatus("danger");
      setAlertTitle("An error has occured: " + response.errorMessage);
      return;
    }

    setAlertStatus("success");
    setAlertTitle("Your changes has been save successfully");

    setTimeout(() => {
      setAlertStatus("");
      setAlertTitle("");
    }, 5000);
  };

  return (
    <div className="grid grid-cols-12">
      <FormProvider {...form}>
        <Card className=" max-w-3xl p-4 col-span-8">
          {alertStatus && (
            <Alert
              className="absolute"
              color={alertStatus}
              title={alertTitle}
            />
          )}

          <CardBody>
            <div className="flex flex-col space-y-2 mb-8">
              {client?.id ? (
                <>
                  <span className=" text-2xl">
                    Welcome to the edit client page
                  </span>
                  <span className=" text-sm text-foreground-400 ">
                    Fill the required fields and start managing your client 📝
                  </span>
                </>
              ) : (
                <>
                  <span className=" text-2xl">
                    Welcome to the new client page
                  </span>
                  <span className=" text-sm text-foreground-400 ">
                    Fill the required fields and start managing your client 📝
                  </span>
                </>
              )}
            </div>
            <form
              className="justify-center items-center w-full space-y-3"
              onSubmit={form.handleSubmit(onSubmit)}
            >
              <div className="flex w-full space-x-4 items-center">
                <Controller
                  name="name"
                  control={form.control}
                  render={({ field, fieldState }) => (
                    <Input
                      isRequired
                      label="Name"
                      labelPlacement="outside"
                      placeholder="Alam"
                      value={field.value}
                      onValueChange={field.onChange}
                      errorMessage={fieldState.error?.message}
                      isInvalid={!!fieldState.error}
                      startContent={
                        <Icon
                          icon="solar:user-outline"
                          className="text-foreground-400"
                          width="24"
                          height="24"
                        />
                      }
                    />
                  )}
                />
                <Controller
                  name="lastName"
                  control={form.control}
                  render={({ field, fieldState }) => (
                    <Input
                      label="Last Name"
                      labelPlacement="outside"
                      placeholder="Mena Beato"
                      value={field.value}
                      onValueChange={field.onChange}
                      errorMessage={fieldState.error?.message}
                      isInvalid={!!fieldState.error}
                      startContent={
                        <Icon
                          icon="solar:user-outline"
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
                  name="identification"
                  control={form.control}
                  render={({ field, fieldState }) => (
                    <Input
                      label="Identification"
                      labelPlacement="outside"
                      placeholder="000-0000000-0"
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
                  name="email"
                  control={form.control}
                  render={({ field, fieldState }) => (
                    <Input
                      label="Email"
                      labelPlacement="outside"
                      placeholder="Amenabeato@gmail.com"
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
                <Controller
                  name="phoneNumber"
                  control={form.control}
                  render={({ field, fieldState }) => (
                    <Input
                      label="Phone number"
                      labelPlacement="outside"
                      placeholder="+1 000-000-0000"
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
              {/* <Textarea
            className="w-full"
            label="Notes"
            placeholder="Adding important notes."
          /> */}
              <div className="flex w-full space-x-4 justify-end pt-4">
                <Button
                  color="danger"
                  variant="bordered"
                  onPress={() => router.push("/clients")}
                >
                  Cancel
                </Button>
                <Button type="submit" color="secondary" isLoading={isLoading}>
                  Save
                </Button>
              </div>
            </form>
          </CardBody>
        </Card>
        <AddressesList />
      </FormProvider>
    </div>
  );
}

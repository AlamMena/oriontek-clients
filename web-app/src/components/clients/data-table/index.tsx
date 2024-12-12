"use client";
import React from "react";
import {
  Table,
  TableHeader,
  TableColumn,
  TableBody,
  TableRow,
  TableCell,
  Input,
  Button,
  DropdownTrigger,
  Dropdown,
  DropdownMenu,
  DropdownItem,
  Chip,
  User,
  useDisclosure,
} from "@nextui-org/react";
import { BottomContent } from "./bottom-content";
import { TopContent } from "./top-content";
import { Client } from "@/lib/clients/types";
import { Icon } from "@iconify/react";
import { ClientFormDrawer } from "../form/drawer";
import { useRouter } from "next/navigation";
import ConfirmationForm from "./confirmation-modal";
import { removeClient } from "@/lib/clients/actions";
import { toast } from "react-toastify";
export function capitalize(s: string) {
  return s ? s.charAt(0).toUpperCase() + s.slice(1).toLowerCase() : "";
}

export const columns = [
  { name: "ID", uid: "id" },
  { name: "NAME", uid: "name", sortable: true },
  { name: "LAST NAME", uid: "lastName", sortable: true },
  { name: "IDENTIFICATION", uid: "identification", sortable: true },
  { name: "PHONE", uid: "phoneNumber" },
  { name: "EMAIL", uid: "email" },
  { name: "Actions", uid: "actions" },
];

export default function DataTable({
  clients,
  pages,
}: {
  clients: Client[];
  pages: number;
}) {
  const { isOpen, onOpen, onOpenChange } = useDisclosure();

  const router = useRouter();
  const renderCell = React.useCallback(
    (client: Client, columnKey: React.Key) => {
      const cellValue = client[columnKey as keyof Client];
      switch (columnKey) {
        case "name":
          return (
            <User
              avatarProps={{ radius: "lg", src: "" }}
              description={client.email}
              name={cellValue}
            >
              {client.email}
            </User>
          );
        case "Identification":
          return (
            <div className="flex flex-col">
              <p className="text-bold text-small capitalize">{cellValue}</p>
              <p className="text-bold text-tiny capitalize text-default-400">
                {client.identification}
              </p>
            </div>
          );
        case "status":
          return (
            <Chip
              className="capitalize"
              // color={statusColorMap[user.status]}
              size="sm"
              variant="flat"
            >
              {cellValue}
            </Chip>
          );
        case "actions":
          return (
            <div className="relative flex justify-end items-center gap-2">
              <Button
                variant="light"
                isIconOnly
                onPress={() => router.push(`clients/${client.id}`)}
              >
                <Icon icon="solar:pen-2-outline" width="24" height="24" />
              </Button>
              <ConfirmationForm client={client} />
            </div>
          );
        default:
          return cellValue;
      }
    },
    []
  );

  return (
    <Table
      isHeaderSticky
      aria-label="Example table with custom cells, pagination and sorting"
      bottomContent={<BottomContent pages={pages} />}
      bottomContentPlacement="outside"
      classNames={{
        wrapper: "max-h-[382px]",
      }}
      // selectionMode="multiple"
      topContent={<TopContent />}
      topContentPlacement="outside"
    >
      <TableHeader columns={columns}>
        {(column) => (
          <TableColumn
            key={column.uid}
            align={column.uid === "actions" ? "center" : "start"}
            allowsSorting={column.sortable}
          >
            {column.name}
          </TableColumn>
        )}
      </TableHeader>
      <TableBody emptyContent={"No users found"} items={clients}>
        {(item) => (
          <TableRow key={item.id}>
            {(columnKey) => (
              <TableCell>{renderCell(item, columnKey)}</TableCell>
            )}
          </TableRow>
        )}
      </TableBody>
    </Table>
  );
}

import { SaveClientBreadcrumb } from "@/components/clients/breadcrums/edit-client";
import { ClientForm } from "@/components/clients/form";
import { getClientById } from "@/lib/clients/actions";
import { Client } from "@/lib/clients/types";
import { notFound, redirect } from "next/navigation";
import { toast } from "react-toastify";

export default async function EditClientPage({
  params,
}: {
  params: Promise<{ id: number }>;
}) {
  const { id } = await params;
  const client = (await getClientById({ id: id })) as Client;

  if (!client) {
    notFound();
  }
  return (
    <div className="flex flex-col space-y-8">
      <div className="flex flex-col space-y-2">
        <span className="text-3xl font-bold">Editing client #{id}</span>
      </div>
      <SaveClientBreadcrumb clientId={id} />
      <ClientForm client={client} />
    </div>
  );
}

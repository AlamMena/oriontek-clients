import { AddressesList } from "@/components/clients/addresses-list";
import { SaveClientBreadcrumb } from "@/components/clients/breadcrums/edit-client";
import { ClientForm } from "@/components/clients/form";

export default function CreateClientPage() {
  return (
    <div className="flex flex-col space-y-8">
      <div className="flex flex-col space-y-2">
        <span className="text-3xl font-bold">Editing client #188291</span>
      </div>
      <SaveClientBreadcrumb />
      <ClientForm />
    </div>
  );
}

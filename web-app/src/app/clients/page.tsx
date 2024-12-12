import { Button } from "@nextui-org/react";
import ClientsDataTable from "../../components/clients/data-table";
import { getClients } from "@/lib/clients/actions";

export default async function ClientsPage({
  searchParams,
}: {
  searchParams: Promise<{ page: number; search: string }>;
}) {
  const { search, page } = await searchParams;
  const res = await getClients({
    page,
    search,
    limit: 10,
  });
  return (
    <div className="flex flex-col space-y-8">
      <div className="flex flex-col space-y-2">
        <span className="text-4xl font-bold">Clients</span>
        <span>
          Welcome to Oriontek clients 👋. Handle all yor clients in one place!
        </span>
      </div>
      <ClientsDataTable
        clients={res.clients}
        pages={Math.ceil(res.dataCount / 10)}
      />
    </div>
  );
}

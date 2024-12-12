import {
  Button,
  Dropdown,
  DropdownMenu,
  DropdownTrigger,
  Input,
} from "@nextui-org/react";
import React from "react";
import { ClientForm } from "../form";
import { useRouter } from "next/navigation";
import { Icon } from "@iconify/react/dist/iconify.js";

export const TopContent = () => {
  const router = useRouter();

  const [filterValue, setFilterValue] = React.useState("");
  const [rowsPerPage, setRowsPerPage] = React.useState(5);

  const onSearchChange = React.useCallback((value?: string) => {
    if (value) {
      setFilterValue(value);
    } else {
      setFilterValue("");
    }
    router.push(`/clients?page=1&search=${value}`);
  }, []);

  const onClear = React.useCallback(() => {
    setFilterValue("");
    router.push(`/clients?page=1&search=${""}`);
  }, []);

  const onRowsPerPageChange = React.useCallback(
    (e: React.ChangeEvent<HTMLSelectElement>) => {
      setRowsPerPage(Number(e.target.value));
    },
    []
  );

  function debounce(func: (...args: any[]) => void, delay: number) {
    let timer: NodeJS.Timeout;
    return (...args: any[]) => {
      clearTimeout(timer);
      timer = setTimeout(() => {
        func(...args);
      }, delay);
    };
  }

  const debouncedNavigate = React.useCallback(
    debounce((value: string) => {
      if (value.trim() !== "") {
        router.push("/sim");
      }
    }, 300),
    []
  );

  return React.useMemo(() => {
    return (
      <div className="flex flex-col gap-4">
        <div className="flex  gap-3 items-start">
          <Input
            isClearable
            className="w-full sm:max-w-[44%]"
            placeholder="Search by name..."
            // startContent={<SearchIcon />}
            value={filterValue}
            onClear={() => onClear()}
            onValueChange={onSearchChange}
          />
          <Button onPress={() => router.push("/clients/create")} isIconOnly>
            <Icon
              icon="solar:add-circle-outline"
              className="text-foreground-600"
              width="24"
              height="24"
            />
          </Button>
        </div>
        <div className="flex justify-between items-center">
          <span className="text-default-400 text-small">
            {/* Total {totalData} clients */}
          </span>
        </div>
      </div>
    );
  }, [filterValue, onSearchChange, onRowsPerPageChange]);
};

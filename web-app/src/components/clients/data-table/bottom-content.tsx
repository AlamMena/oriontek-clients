"use client";
import { Button, Pagination } from "@nextui-org/react";
import { redirect, useRouter } from "next/navigation";
import React from "react";

export const BottomContent = ({ pages }: { pages: number }) => {
  const router = useRouter();
  const [page, setPage] = React.useState(1);

  const handleSetPage = (page: number) => {
    setPage(page);
    router.push("/clients?page=" + page);
  };
  const onNextPage = React.useCallback(() => {
    if (page < pages) {
      setPage(page + 1);
      router.push("/clients?page=" + page);
    }
  }, [page, pages]);

  const onPreviousPage = React.useCallback(() => {
    if (page > 1) {
      setPage(page - 1);
      router.push("/clients?page=" + page);
    }
  }, [page]);

  return React.useMemo(() => {
    return (
      <div className="py-2 px-2 flex justify-between items-center">
        <Pagination
          isCompact
          showControls
          showShadow
          color="primary"
          page={page}
          total={pages}
          onChange={handleSetPage}
        />
        <div className="hidden sm:flex w-[30%] justify-end gap-2">
          <Button
            isDisabled={pages === 1}
            size="sm"
            variant="flat"
            onPress={onPreviousPage}
          >
            Previous
          </Button>
          <Button
            isDisabled={pages === 1}
            size="sm"
            variant="flat"
            onPress={onNextPage}
          >
            Next
          </Button>
        </div>
      </div>
    );
  }, [page, pages]);
};

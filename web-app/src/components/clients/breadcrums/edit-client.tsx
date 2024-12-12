"use client";

import { BreadcrumbItem, Breadcrumbs } from "@nextui-org/react";

export function SaveClientBreadcrumb({ clientId }: { clientId?: number }) {
  return (
    <Breadcrumbs>
      <BreadcrumbItem>Clients</BreadcrumbItem>
      <BreadcrumbItem>#{clientId ?? "new"}</BreadcrumbItem>
    </Breadcrumbs>
  );
}

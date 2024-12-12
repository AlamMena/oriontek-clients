"use server";
import { revalidatePath } from "next/cache";
import { axiosInstance } from "../common/axios-instance";
import { ApiResponse } from "../common/response";
import { Client } from "./types";
import { AxiosError } from "axios";

export async function getClients({
  page,
  search,
  limit,
}: {
  page: number;
  search?: string;
  limit: number;
}) {
  const searchParam = search ? `&name=${search}` : "";
  console.log("url", `clients/name?page=${page ?? 1}&limit=10${searchParam}`);
  const { data } = await axiosInstance.get(
    `clients/name?page=${page ?? 1}&limit=10${searchParam}`
  );
  return data as { dataCount: number; clients: Client[] };
}

export async function getClientById({ id }: { id: number }) {
  try {
    const { data } = await axiosInstance.get(`client/${id}`);
    console.log(data);
    return data as Client;
  } catch (error) {
    return null;
  }
}

export async function saveClient(client: Client): Promise<ApiResponse<Client>> {
  try {
    let response: ApiResponse<Client>;
    if (!client.id) {
      const res = await axiosInstance.post(`client`, client);
      response = res.data;
    } else {
      const res = await axiosInstance.patch(`client`, client);
      response = res.data;
    }
    return response;
  } catch (error) {
    const parsedError = error as AxiosError;
    let apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<Client>;
    return {
      errorMessage: apiResponse.errorMessage,
      status: parsedError.status,
    };
  }
}

export async function removeClient(
  client: Client
): Promise<ApiResponse<Client>> {
  try {
    let response: ApiResponse<Client>;
    const res = await axiosInstance.delete(`client/` + client.id);
    response = res.data;
    revalidatePath("/clients");

    return response;
  } catch (error) {
    const parsedError = error as AxiosError;
    let apiResponse = parsedError.response
      ?.data as unknown as ApiResponse<Client>;
    return {
      errorMessage: apiResponse.errorMessage,
      status: parsedError.status,
    };
  }
}

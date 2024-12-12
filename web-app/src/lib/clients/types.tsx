import z from "zod";

export interface Client {
  id?: number;
  name: string;
  lastName: string;
  email: string;
  phoneNumber: string;
  identification: string;
}

export interface ClientAddress {
  id?: number;
  street: string;
  city: string;
  zipCode: string;
}

export const ClientAddressSchema = z.object({
  id: z.number().optional(),
  street: z.string().min(2),
  city: z.string().min(2),
  zipCode: z.string().min(2),
});

export const ClientSchema = z.object({
  id: z.number().optional(),
  name: z
    .string()
    .min(2, { message: "Name must contain at least 2 characters" })
    .max(50),
  lastName: z
    .string()
    .min(2, { message: "Last name must contain at least 2 characters" })
    .max(50),
  identification: z
    .string()
    .min(5, { message: "Identification must contain at least 5 characters" })
    .max(50),
  email: z.string().email({ message: "Email must be a valid email" }),
  phoneNumber: z.string().min(2),
  addresses: z.array(ClientAddressSchema).optional(),
});

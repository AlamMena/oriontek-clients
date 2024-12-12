"use client";
import { Button, Image, Link } from "@nextui-org/react";

export default function NotFound() {
  return (
    <div className="flex flex-col space-y-2 justify-center items-center w-full mt-40 ">
      <Image
        alt="NextUI Album Cover"
        src="https://cdn-icons-png.flaticon.com/128/14005/14005534.png"
        width={80}
      />
      <span className="text-4xl">Upps! client not found</span>
      <p>Could not find requested resource.</p>
      <Link href="/clients">Take me back to clients list</Link>
    </div>
  );
}

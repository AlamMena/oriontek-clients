import { Providers } from "@/providers/providers";
import "./globals.css";
import NavBar from "../components/nav";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en" className="dark" suppressHydrationWarning>
      <body suppressHydrationWarning>
        <Providers>
          <NavBar />
          <ToastContainer />
          <main className="container max-w-7xl mx-auto p-6">{children}</main>
        </Providers>
      </body>
    </html>
  );
}

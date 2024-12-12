export interface ApiResponse<T> {
  Data?: T;
  errorMessage?: string;
  status?: number;
}

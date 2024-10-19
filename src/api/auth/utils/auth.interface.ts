export interface ILoginPayload {
  email: string;
  password: string;
  device?: string;
}

export interface ILoginResponse {
  access_token: string;
}
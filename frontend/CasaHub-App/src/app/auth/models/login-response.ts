import { UserResponse } from "./user-response";

export interface LoginResponse {
    token: string;
    expiration: string;
    user: UserResponse;
}

import { environment } from "../../../environments/environment";

export const API = {
    base: environment.apiUrl,
    endpoints: {
        users: `${environment.apiUrl}/users`,
        auth: {
            login: `${environment.apiUrl}/auth/login`
        }
    }
};
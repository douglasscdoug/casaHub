import { HttpClient } from '@angular/common/http';
import { inject, Service } from '@angular/core';
import { CreateUserRequest } from '../models/create-user-request';
import { Observable, tap } from 'rxjs';
import { API } from '../../core/config/api.config';
import { LoginRequest } from '../models/login-request';
import { LoginResponse } from '../models/login-response';
import { UserResponse } from '../models/user-response';

@Service()
export class AuthService {
    private readonly http = inject(HttpClient);
    private readonly TOKEN_KEY = 'casahub_token';
    private readonly EXPIRATION_KEY = 'casahub_expiration';
    private readonly USER_KEY = 'casahub_user';

    cadastrar(request: CreateUserRequest): Observable<unknown> {
        return this.http.post<unknown>(API.endpoints.users, request);
    }

    login(request: LoginRequest): Observable<LoginResponse> {
        return this.http
            .post<LoginResponse>(API.endpoints.auth.login, request)
            .pipe(tap(response => this.salvarSessao(response)));
    }

    getToken(): string | null {
        return sessionStorage.getItem(this.TOKEN_KEY);
    }

    getUsuario(): UserResponse | null {
        const usuario = sessionStorage.getItem(this.USER_KEY);

        if (!usuario) {
            return null;
        }

        return JSON.parse(usuario) as UserResponse;
    }

    getExpiration(): string | null {
        return sessionStorage.getItem(this.EXPIRATION_KEY);
    }

    logout(): void {
        sessionStorage.removeItem(this.TOKEN_KEY);
        sessionStorage.removeItem(this.EXPIRATION_KEY);
        sessionStorage.removeItem(this.USER_KEY);
    }

    isAuthenticated(): boolean {
        const token = this.getToken();
        const expiration = this.getExpiration();

        if (!token || !expiration) {
            return false;
        }

        const expirado = new Date(expiration).getTime() <= Date.now();

        if (expirado) {
            this.logout();
            return false;
        }

        return true;
    }

    private salvarSessao(response: LoginResponse): void {
        sessionStorage.setItem(this.TOKEN_KEY, response.token);
        sessionStorage.setItem(this.EXPIRATION_KEY, response.expiration);
        sessionStorage.setItem(this.USER_KEY, JSON.stringify(response.user));
    }
}

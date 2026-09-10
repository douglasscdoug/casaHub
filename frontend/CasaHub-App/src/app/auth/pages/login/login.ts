import { Component, inject, NgZone, signal } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../services/auth-service';
import { Router, RouterLink } from '@angular/router';
import { LoginRequest } from '../../models/login-request';
import { finalize } from 'rxjs';

@Component({
  imports: [ReactiveFormsModule, RouterLink],
  selector: 'app-login',
  styleUrl: './login.css',
  templateUrl: './login.html',
})
export class Login {
  private readonly fb = inject(NonNullableFormBuilder);
  private readonly authService = inject(AuthService);
  private readonly router = inject(Router);
  private readonly ngZone = inject(NgZone);

  readonly loginForm = this.fb.group({
    email: [
      '',
      [
        Validators.required,
        Validators.email
      ]
    ],
    senha: [
      '',
      Validators.required
    ]
  });

  formularioEnviado = false;
  autenticando = signal(false);
  erroLogin = signal('');
  mensagemSucesso = signal('');

  constructor() {
    const mensagem = history.state?.mensagem;

    if (mensagem) {
      this.mensagemSucesso.set(mensagem);
    }
  }

  onSubmit(): void {
    this.formularioEnviado = true;

    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }

    this.autenticando.set(true);

    const { email, senha } = this.loginForm.getRawValue();

    const request: LoginRequest = {
      email,
      password: senha
    };

    this.authService.login(request)
      .pipe(finalize(() => this.autenticando.set(false)))
      .subscribe({
        next: () => {
          this.router.navigate(['/']);
        },
        error: (error) => {
          if (error.status === 401) {
            this.erroLogin.set(error.error?.Message ?? 'Usuário ou senha inválidos.');
            return;
          }

          this.erroLogin.set('Não foi possível realizar o login. Tente novamente.');
        }
      });
  }
}
import { Component, inject, signal } from '@angular/core';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { fieldsMatchValidator } from '../../../core/validators/fieldsMatchValidator';
import { Router, RouterLink } from '@angular/router';
import { passwordValidator } from '../../../core/validators/password.validator';
import { AuthService } from '../../services/auth-service';
import { CreateUserRequest } from '../../models/create-user-request';
import { CommonModule } from '@angular/common';
import { finalize } from 'rxjs';

@Component({
  imports: [ReactiveFormsModule, RouterLink, CommonModule],
  selector: 'app-cadastro',
  styleUrl: './cadastro.css',
  templateUrl: './cadastro.html',
})
export class Cadastro {
  private readonly fb = inject(NonNullableFormBuilder);
  private readonly authSertvice = inject(AuthService);
  private readonly router = inject(Router);

  senhaEmFoco = false;
  formularioEnviado = false;
  cadastrando = signal(false);
  erroCadastro = signal('');

  readonly cadastroForm = this.fb.group(
    {
      name: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100), passwordValidator()]],
      confirmPassword: ['', [Validators.required]]
    },
    {
      validators: fieldsMatchValidator('password', 'confirmPassword')
    }
  )

  onSubmit(): void {
    this.formularioEnviado = true;

    if (this.cadastroForm.invalid) {
      this.cadastroForm.markAllAsTouched();
      return;
    }

    this.cadastrando.set(true);

    const { name: name, email, password: password } = this.cadastroForm.getRawValue();

    const request: CreateUserRequest = {
      name,
      email,
      password
    };

    this.authSertvice.cadastrar(request)
      .pipe(finalize(() => this.cadastrando.set(false)))
      .subscribe({
        next: () => {
          this.router.navigate(['/login'], {
            state: {
              mensagem: 'Conta criada com sucesso! Agora faça login para acessar o CasaHub.'
            }
          });
        },
        error: (error) => {
          if (error.status === 400) {
            this.erroCadastro.set(
              error.error?.Message ??
              'Não foi possível criar sua conta. Verifique os dados informados.'
            );
            return;
          }

          this.erroCadastro.set('Não foi possível criar sua conta. Tente novamente.');
        }
      });
  }
}

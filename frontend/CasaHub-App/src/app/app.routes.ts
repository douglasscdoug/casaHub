import { Routes } from '@angular/router';
import { Layout } from './layout/layout';
import { authGuard } from './core/guards/auth-guard';
import { guestGuard } from './core/guards/guest-guard';

export const routes: Routes = [
    {
        path: 'login',
        canActivate: [guestGuard],
        loadComponent: () =>
            import('./auth/pages/login/login')
                .then(m => m.Login)
    },
    {
        path: 'cadastro',
        canActivate: [guestGuard],
        loadComponent: () =>
            import('./auth/pages/cadastro/cadastro')
                .then(m => m.Cadastro)
    },
    {
        path: '',
        component: Layout,
        canActivate: [authGuard],
        children: [
            {
                path: '',
                redirectTo: 'dashboard',
                pathMatch: 'full'
            },
            {
                path: 'dashboard',
                loadChildren: () =>
                    import('./features/dashboard/dashboard.routes')
                        .then(m => m.DASHBOARD_ROUTES)
            },
            {
                path: 'financas',
                loadChildren: () =>
                    import('./features/financas/financas.routes')
                        .then(m => m.FINANCAS_ROUTES)
            },
            {
                path: 'compras',
                loadChildren: () =>
                    import('./features/compras/compras.routes')
                        .then(m => m.COMPRAS_ROUTES)
            },
            {
                path: 'tarefas',
                loadChildren: () =>
                    import('./features/tarefas/tarefas.routes')
                        .then(m => m.TAREFAS_ROUTES)
            },
            {
                path: 'calendario',
                loadChildren: () =>
                    import('./features/calendario/calendario.routes')
                        .then(m => m.CALENDARIO_ROUTES)
            },
            {
                path: 'configuracoes',
                loadChildren: () =>
                    import('./features/configuracoes/configuracoes.routes')
                        .then(m => m.CONFIGURACOES_ROUTES)
            }
        ]
    },

    {
        path: '**',
        redirectTo: 'dashboard'
    }
];
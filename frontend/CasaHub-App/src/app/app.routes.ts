import { Routes } from '@angular/router';
import { Layout } from './layout/layout';

export const routes: Routes = [
    {
        path: '',
        component: Layout,
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
import { Routes } from '@angular/router'

export const Client_Routes: Routes = [
    {
        path: '',
        loadChildren: () => import('../Client/client.module').then(s => s.ClientModule)
    }
];
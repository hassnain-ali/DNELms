import { Routes } from '@angular/router'

export const Admin_Routes: Routes = [
    {
        path: '',
        loadChildren: () => import('../admin/admin.module').then(s => s.AdminModule)
    }
];
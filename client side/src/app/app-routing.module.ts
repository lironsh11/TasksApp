//*** create components */

import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';

//**  create routing table mapping file   app.routes.ts */

export const routes: Routes = [
    { path: "", redirectTo: "/home", pathMatch: 'full' },
    { path: "home", component: HomeComponent },
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);
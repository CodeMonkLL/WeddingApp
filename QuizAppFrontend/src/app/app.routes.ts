import { Routes } from '@angular/router';
import { HomeComponent } from './Views/home/home.component';
import { GuestbookComponent } from './Components/guestbook/guestbook.component';
import { AboutComponent } from './Views/about/about.component';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full', // Automatische Umleitung von "/" zu "/home"
  },
  { path: 'home', component: HomeComponent },
  { path: 'gaestebuch', component: GuestbookComponent },
  { path: 'about', component: AboutComponent },
];

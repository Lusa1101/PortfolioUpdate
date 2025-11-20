import { Routes } from '@angular/router';
import { App } from './app';
import path from 'path';
import { Blog } from '../components/blog/blog';
import { Home } from './home/home';

export const routes: Routes = [
    {
        path: '', 
        component: Home
    },
    {
        path: 'blog',
        component: Blog
    }
];

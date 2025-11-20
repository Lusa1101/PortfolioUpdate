import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { provideRouter } from '@angular/router';
import { provideServerRendering } from '@angular/platform-server';
import 'zone.js';
import { routes } from './app/app.routes';

bootstrapApplication(App, {
 providers: 
 [
    provideRouter(routes)
]
}).catch(err => console.error(err));
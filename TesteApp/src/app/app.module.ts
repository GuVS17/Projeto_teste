import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProdutoComponent } from './components/Produto/Produto.component';
import { NavComponent } from './components/nav/nav.component';
import { provideHttpClient } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { DashboardComponent } from './components/Dashboard/Dashboard.component';
import { TituloComponent } from './components/titulo/titulo.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    ProdutoComponent,
    NavComponent,
    DashboardComponent,
    TituloComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
  ],
  providers: [
    provideHttpClient()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

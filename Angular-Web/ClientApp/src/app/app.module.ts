import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { EmpresaComponent } from './empresa/empresa.component';
import { EmpresaServicio } from './empresa/empresa.service';
import { PersonaComponent } from './persona/persona.component';
import { EmpresaFormComponent } from './empresa/empresa-form/empresa-form.component';
import { CategoriaComponent } from './categorias/categoria/categoria.component';
import { CategoriaService } from './categorias/servicio-model/categoria.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EmpresaComponent,
    PersonaComponent,
    EmpresaFormComponent,
    CategoriaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'empresa', component: EmpresaComponent },
      { path: 'persona', component: PersonaComponent },
      { path: 'empresa-form', component: EmpresaFormComponent },
      { path: 'categoria', component: CategoriaComponent }
    ])
  ],
    providers: [
        EmpresaServicio,
        CategoriaService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }

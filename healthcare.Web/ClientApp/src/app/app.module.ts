import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ConsultorioCadastroComponent } from './consultorio/cadastro/consultorio.cadastro.component';
import { ConsultorioServico } from './servicos/ConsultorioServico';
import { ConsultorioListaComponent } from './consultorio/lista/consultorio.lista.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ConsultorioCadastroComponent,
    ConsultorioListaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'cadastro-consultorio', component: ConsultorioCadastroComponent },
      { path: 'lista-consultorio', component: ConsultorioListaComponent },
    ])
  ],
  providers: [ConsultorioServico],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ConsultorioCadastroComponent } from './consultorio/cadastro/consultorio.cadastro.component';
import { ConsultorioServico } from './servicos/ConsultorioServico';
import { ConsultorioListaComponent } from './consultorio/lista/consultorio.lista.component';
import { MedicoCadastroComponent } from './medico/cadastro/medico.cadastro.component';
import { MedicoListaComponent } from './medico/lista/medico.lista.component';
import { MedicoServico } from './servicos/MedicoServico';
import { ConsultorioMedicoListaComponent } from './consultoriomedico/lista/consultoriomedico.lista.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,    
    ConsultorioCadastroComponent,
    ConsultorioListaComponent,
    MedicoCadastroComponent,
    MedicoListaComponent,
    ConsultorioMedicoListaComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },      
      { path: 'cadastro-consultorio', component: ConsultorioCadastroComponent },
      { path: 'cadastro-medico', component: MedicoCadastroComponent },
      { path: 'lista-consultorio', component: ConsultorioListaComponent },
      { path: 'lista-medico', component: MedicoListaComponent },
      { path: 'lista-consultorio-medico', component: ConsultorioMedicoListaComponent },
    ])
  ],
  providers: [ConsultorioServico, MedicoServico],
  bootstrap: [AppComponent]
})
export class AppModule { }

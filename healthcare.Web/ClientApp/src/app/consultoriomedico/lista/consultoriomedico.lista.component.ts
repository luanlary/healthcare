import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import {  MedicoServico } from "../../servicos/MedicoServico";
import { Medico } from "../../Modelo/medico";
import { Consultorio } from "../../modelo/consultorio";
import { ConsultorioMedico } from "../../modelo/consultoriomedico";
import { ConsultorioServico } from "../../servicos/ConsultorioServico";
import { ConsultorioMedicoServico } from "../../servicos/ConsultorioMedicoServico";

@Component({
  selector: "pesquisa-consultorio-medico",
  templateUrl: "consultoriomedico.lista.component.html",
  styleUrls: ["consultoriomedico.lista.component.css"]
})


export class ConsultorioMedicoListaComponent implements OnInit {

  public medicos: Medico[];
  public consultorios: Consultorio[];
  public consultorioMedico: ConsultorioMedico;
  public consultorioMedicos: ConsultorioMedico[];
  public mensagem: string;
  public ativarSpinner: boolean;

  constructor(private medicoServico: MedicoServico, private router: Router,
    private consultorioServico: ConsultorioServico, private consultoriomedicoServico: ConsultorioMedicoServico) {
    this.ativarSpinner = true;

    /*this.consultoriomedicoServico.ObterTodosMedicosServicos()
      .subscribe(
        lista_consultoriomedicos => {
          this.consultorioMedicos = lista_consultoriomedicos;
          this.ativarSpinner = false;
        },
        e => {
          console.log(e.error);
          this.ativarSpinner = false;
          this.mensagem = e.error;
        }
      );*/
  }

  public adicionarMedicoServico() {
  }

  public deletarMedico(medico: Medico) {

    
  }

  ngOnInit(): void {
    this.medicoServico.ObterTodosMedicos()
      .subscribe(
        lista_medicos => {
          this.medicos = lista_medicos;
        },
        e => {
          console.log(e.error);
        }
      );

    this.consultorioServico.ObterTodosConsultorios()
      .subscribe(
        lista_consultorios => {
          this.consultorios = lista_consultorios;
        },
        e => {
          console.log(e.error);
        }
      );
  }

}

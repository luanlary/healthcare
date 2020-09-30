import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
<<<<<<< HEAD
import { MedicoServico } from "../../servicos/MedicoServico";
=======
import {  MedicoServico } from "../../servicos/MedicoServico";
>>>>>>> e567db1ea797874a49190c7efac82e322884e61d
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
<<<<<<< HEAD
  public MedicoId: number;
  public ConsultorioId: number;
=======
>>>>>>> e567db1ea797874a49190c7efac82e322884e61d
  public mensagem: string;
  public ativarSpinner: boolean;

  constructor(private medicoServico: MedicoServico, private router: Router,
<<<<<<< HEAD
    private consultorioServico: ConsultorioServico, private consultorioMedicoServico: ConsultorioMedicoServico) {
=======
    private consultorioServico: ConsultorioServico, private consultoriomedicoServico: ConsultorioMedicoServico) {
>>>>>>> e567db1ea797874a49190c7efac82e322884e61d
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
<<<<<<< HEAD
   alert(this.MedicoId + " - " + this.ConsultorioId);
=======
>>>>>>> e567db1ea797874a49190c7efac82e322884e61d
  }

  public deletarMedico(medico: Medico) {

<<<<<<< HEAD

=======
    
>>>>>>> e567db1ea797874a49190c7efac82e322884e61d
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

import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import {  MedicoServico } from "../../servicos/MedicoServico";
import { Medico } from "../../Modelo/medico";

@Component({
  selector: "pesquisa-medico",
  templateUrl: "medico.lista.component.html",
  styleUrls: ["medico.lista.component.css"]
})


export class MedicoListaComponent implements OnInit {

  public medicos: Medico[];
  public mensagem: string;
  public ativarSpinner: boolean;

  constructor(private medicoServico: MedicoServico, private router: Router) {
    this.ativarSpinner = true;
    this.medicoServico.ObterTodosMedicos()
      .subscribe(
        lista_medicos => {
          this.medicos = lista_medicos;
          this.ativarSpinner = false;
        },
        e => {
          console.log(e.error);
          this.ativarSpinner = false;
          this.mensagem = e.error;
        }
      );
  }

  public adicionarMedico() {
    sessionStorage.setItem("medicoSessao","");
    this.router.navigate(["/cadastro-medico"]);
  }

  public deletarMedico(medico: Medico) {
   var retorno = confirm("Deseja realmente deletar o médico selecionado?");
    if (retorno) {
      this.medicoServico.deletar(medico)
        .subscribe(
          lista_medico => {
            this.medicos = lista_medico;
          },
          e => {
            console.log(e.error)
          }
        );
    }
    
  }
  public editarMedico(medico: Medico) {
    var retorno = confirm("Deseja realmente editar o médico selecionado?");
    if (retorno) {
      sessionStorage.setItem("medicoSessao", JSON.stringify(medico));
      this.router.navigate(["/cadastro-medico"]);
    }

  }

  ngOnInit(): void {


  }

}

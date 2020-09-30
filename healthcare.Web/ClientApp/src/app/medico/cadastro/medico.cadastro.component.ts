import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { MedicoServico } from "../../servicos/MedicoServico";
import { Medico } from "../../modelo/medico";

@Component({
  selector: "cadastro-medico",
  templateUrl: "medico.cadastro.component.html",
  styleUrls: ["medico.cadastro.component.css"]
})
export class MedicoCadastroComponent implements OnInit {
  public medico: Medico;
  public ativar_spinner: boolean;
  public mensagem: string;
  
  constructor(private medicoServico: MedicoServico, private router: Router, private activatedRouter: ActivatedRoute) {

  }
  ngOnInit(): void {
    var medicoEdicao = sessionStorage.getItem("medicoSessao");
    if ((medicoEdicao != "") && (medicoEdicao != null))
      this.medico = JSON.parse(medicoEdicao)
    else
      this.medico = new Medico();    
  }

  public cadastrar() {
    this.ativar_spinner = true;

    this.medicoServico.cadastrarConsultorio(this.medico)
      .subscribe(
        consultorioJson => {
          this.mensagem = "Medico salvo com sucesso!";
          this.ativar_spinner = false;
          var medicoEdicao = sessionStorage.setItem("medicoSessao","");
        },
        e => {
          this.mensagem = e.error;
          this.ativar_spinner = false;
        }
      );
  }

}

import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Consultorio } from "../../modelo/consultorio";
import { ConsultorioServico } from "../../servicos/ConsultorioServico";

@Component({
  selector: "cadastro-consultorio",
  templateUrl: "consultorio.cadastro.component.html",
  styleUrls: ["consultorio.cadastro.component.css"]
})
export class ConsultorioCadastroComponent implements OnInit {
  public consultorio: Consultorio;
  public ativar_spinner: boolean;
  public mensagem: string;
  
  constructor(private consultorioServico: ConsultorioServico, private router: Router, private activatedRouter: ActivatedRoute) {

  }
  ngOnInit(): void {
    var consultorioEdicao = sessionStorage.getItem("consultorioSessao");
    if (consultorioEdicao != "")
      this.consultorio = JSON.parse(consultorioEdicao)
    else
      this.consultorio = new Consultorio();
    
  }

  public cadastrar() {
    this.ativar_spinner = true;

    this.consultorioServico.cadastrarConsultorio(this.consultorio)
      .subscribe(
        consultorioJson => {
          this.mensagem = "Consultorio salvo com sucesso!";
          this.ativar_spinner = false;
          var consultorioEdicao = sessionStorage.setItem("consultorioSessao","");
        },
        e => {
          this.mensagem = e.error;
          this.ativar_spinner = false;
        }
      );
  }

}

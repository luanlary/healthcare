import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ConsultorioServico } from "../../servicos/ConsultorioServico";
import { Consultorio } from "../../Modelo/consultorio";

@Component({
  selector: "pesquisa-produto",
  templateUrl: "consultorio.lista.component.html",
  styleUrls: ["consultorio.lista.component.css"]
})


export class ConsultorioListaComponent implements OnInit {

  public consultorios: Consultorio[];
  public mensagem: string;
  public ativarSpinner: boolean;

  constructor(private consultorioServico: ConsultorioServico, private router: Router) {
    this.ativarSpinner = true;
    this.consultorioServico.ObterTodosConsultorios()
      .subscribe(
        lista_consultorios => {
          this.consultorios = lista_consultorios;
          this.ativarSpinner = false;
        },
        e => {
          console.log(e.error);
          this.ativarSpinner = false;
          this.mensagem = e.error;
        }
      );
  }

  public adicionarConsultorio() {
    sessionStorage.setItem("consultorioSessao","");
    this.router.navigate(["/cadastro-consultorio"]);
  }

  public deletarConsultorio(consultorio: Consultorio) {
   var retorno = confirm("Deseja realmente deletar o consultório selecionado?");
    if (retorno) {
      this.consultorioServico.deletar(consultorio)
        .subscribe(
          lista_consultorio => {
            this.consultorios = lista_consultorio;
          },
          e => {
            console.log(e.error)
          }
        );
    }
    
  }
  public editarConsultorio(consultorio: Consultorio) {
    var retorno = confirm("Deseja realmente editar o consultorio selecionado?");
    if (retorno) {
      sessionStorage.setItem("consultorioSessao", JSON.stringify(consultorio));
      this.router.navigate(["/cadastro-consultorio"]);
    }

  }

  ngOnInit(): void {


  }

}

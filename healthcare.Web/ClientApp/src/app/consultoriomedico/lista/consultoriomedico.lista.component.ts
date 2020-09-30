import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { MedicoServico } from "../../servicos/MedicoServico";
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

  public MedicoId: number;
  public ConsultorioId: number;

  public mensagem: string;
  public ativarSpinner: boolean;

  constructor(private medicoServico: MedicoServico, private router: Router,

    private consultorioServico: ConsultorioServico, private consultorioMedicoServico: ConsultorioMedicoServico) {


  }

  public adicionarMedicoServico() {
    
    var CosultorioMedicoServicoVar = new ConsultorioMedico();
    CosultorioMedicoServicoVar.consultorioId = this.ConsultorioId;
    CosultorioMedicoServicoVar.medicoId = this.MedicoId;
    
    this.consultorioMedicoServico.cadastrarConsultorioMedico(CosultorioMedicoServicoVar)
      .subscribe(
        lista_consutoriomedico => {
          this.consultorioMedicoServico.ObterTodosMedicosServicos()
            .subscribe(
              nova_lista => {
                this.consultorioMedicos = nova_lista;
              },
              er => {
                console.log(er.error);
              }
            );
        },
         e => {
            console.log(e.error)
        }
      );
   
  }

  public deletarConsultorioMedico(consultoriomedico: ConsultorioMedico) {
    var retorno = confirm("Deseja realmente deletar o médico selecionado?");
    if (!retorno)
      return;
    this.consultorioMedicoServico.deletar(consultoriomedico)
      .subscribe(
        lista_consutoriomedico => {
          this.consultorioMedicoServico.ObterTodosMedicosServicos()
            .subscribe(
              nova_lista => {
                this.consultorioMedicos = nova_lista;
              },
              er => {
                console.log(er.error);
              }
            );
        },
        e => {
          console.log(e.error)
        }
      );
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

    this.ativarSpinner = true;

    this.consultorioMedicoServico.ObterTodosMedicosServicos()
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
      );
  }

}

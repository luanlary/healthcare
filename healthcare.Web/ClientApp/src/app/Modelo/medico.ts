import { ConsultorioMedico } from "./consultoriomedico";

export class Medico {
  public id: number;
  public crm: string;
  public nome: string;
  public telefone: string;
  public valorConsulta: number;
  public consultorioMedicos: ConsultorioMedico[];
}

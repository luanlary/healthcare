import { ConsultorioMedico } from "./consultoriomedico";

export class Consultorio {
  public id: number;
  public endereco: string;
  public telefone: string;
  public nome: string;
  public consultorioMedicos: ConsultorioMedico[];
}

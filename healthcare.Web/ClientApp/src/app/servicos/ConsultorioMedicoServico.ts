import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { ConsultorioMedico } from "../modelo/consultoriomedico";
import { Consultorio } from "../modelo/consultorio";


@Injectable({
providedIn: "root"
})
export class ConsultorioMedicoServico
{

  private baseURL: string;
  private _consultorio: Consultorio;

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
}

constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  this.baseURL = baseUrl;
}

public ObterTodosMedicosServicos(): Observable<ConsultorioMedico[]> {
  return this.http.get<ConsultorioMedico[]>(this.baseURL + "api/consultorio");
}

public deletar(consultorioMedico: ConsultorioMedico): Observable<ConsultorioMedico[]> {

  return this.http.post<ConsultorioMedico[]>(this.baseURL + "api/consultoriomedico/deletar", JSON.stringify(consultorioMedico), { headers: this.headers });
}


public cadastrarConsultorio(consultoriomedico: ConsultorioMedico): Observable<ConsultorioMedico> {
  return this.http.post<ConsultorioMedico>(this.baseURL + "api/consultoriomedico", JSON.stringify(consultoriomedico), { headers: this.headers });
}
}

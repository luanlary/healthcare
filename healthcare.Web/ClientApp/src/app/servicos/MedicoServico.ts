import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

import { Medico } from "../modelo/medico";


@Injectable({
  providedIn: "root"
})
export class MedicoServico {

  private baseURL: string;
  private _medico: Medico;

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  public ObterTodosMedicos(): Observable<Medico[]> {
    return this.http.get<Medico[]>(this.baseURL + "api/medico");
  }

  public deletar(medico: Medico): Observable<Medico[]> {

    return this.http.post<Medico[]>(this.baseURL + "api/medico/deletar", JSON.stringify(medico), { headers: this.headers });
  }


  public cadastrarMedico(medico: Medico): Observable<Medico> {
    return this.http.post<Medico>(this.baseURL + "api/medico", JSON.stringify(medico), { headers: this.headers });
  }
}

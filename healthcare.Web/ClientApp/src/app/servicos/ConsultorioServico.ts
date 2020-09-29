import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Consultorio } from "../modelo/consultorio";


@Injectable({
  providedIn: "root"
})
export class ConsultorioServico {

  private baseURL: string;
  private _consultorio: Consultorio;

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }


  public cadastrarConsultorio(consultorio: Consultorio): Observable<Consultorio> {
    return this.http.post<Consultorio>(this.baseURL + "api/consultorio", JSON.stringify(consultorio), { headers: this.headers });
  }
}

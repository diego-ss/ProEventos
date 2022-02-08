import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';

@Injectable({
  providedIn: 'root'
})
export class EventoService {

  baseUrl = "https://localhost:5001/api/eventos";

  constructor(private httpClient: HttpClient) { }

  getEventos(): Observable<Evento>{
    return this.httpClient.get<Evento>(this.baseUrl);
  }

}

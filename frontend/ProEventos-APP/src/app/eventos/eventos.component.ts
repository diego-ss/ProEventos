import { EventoService } from './../services/evento.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public imgLargura = 50;
  public imgMargem = 2;
  public imgMostrar: boolean = false;
  private _termoBusca: string = "";

  constructor(private eventoService: EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  get termoBusca(): string {
    return this._termoBusca;
  }

  set termoBusca(value: string) {
    this._termoBusca = value;
    this.eventosFiltrados = this.termoBusca ? this.filtrarEventos(this.termoBusca) : this.eventos;
  }

  private getEventos(): void{
    this.eventoService.getEventos().subscribe(
      (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = this.eventos;
      },
      error => console.error(error)
    );
  }

  public alterarVisibilidadeImagem(): void{
    this.imgMostrar = !this.imgMostrar;
  }

  public filtrarEventos(termoBusca: string): any {
    termoBusca = termoBusca.toLowerCase();
    return this.eventos.filter(
            (ev: any) =>
                ev.tema.toLowerCase().indexOf(termoBusca) !== -1 ||
                ev.local.toLowerCase().indexOf(termoBusca) !== -1
          );
  }
}

import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

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
  public modalRef = {} as BsModalRef;
  private _termoBusca: string = "";


  constructor(private eventoService: EventoService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private spinner: NgxSpinnerService) { }

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

  public alterarVisibilidadeImagem(): void{
    this.imgMostrar = !this.imgMostrar;
  }

  private getEventos(): void{

    this.spinner.show();
    this.eventoService.getEventos().subscribe(
      {
        next: (eventos: Evento[]) => {
          this.eventos = eventos;
          this.eventosFiltrados = this.eventos;
        },
        error: (error: any) => {
          console.error(error)
          this.spinner.hide();
          this.toastr.error('falha ao carregar eventos!', 'Ops!');
        },
        complete: ()=> {
          this.spinner.hide();
        }
      });
  }

  public filtrarEventos(termoBusca: string): any {
    termoBusca = termoBusca.toLowerCase();
    console.log(this.eventosFiltrados);
    return this.eventos.filter(
            (ev: any) =>
                ev.tema.toLowerCase().indexOf(termoBusca) !== -1 ||
                ev.local.toLowerCase().indexOf(termoBusca) !== -1
          );
  }

  public openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  public confirm(): void {
    this.modalRef.hide();
    this.toastr.success('evento deletado com sucesso!', 'Sucesso!');
  }

  public decline(): void {
    this.modalRef.hide();
  }

  showSuccess() {
    this.toastr.success('Hello world!', 'Toastr fun!');
  }

  showFail() {
    this.toastr.error('Hello world!', 'Toastr fun!');
  }
}

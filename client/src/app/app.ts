import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal} from '@angular/core';
import { lastValueFrom } from 'rxjs';


@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit{
  // Cyle de vie construction puis Init
  private http = inject(HttpClient)
  protected readonly title ='Dating app';
  //utilisation de signal pour que angular puissse réagir aux changements(zonelessSystem)
  protected members = signal<any>([]);
  
  //Method with subscribe with observable
  // ngOnInit(): void {
  //   //no need to unsubscribe , http request do it automaticaly
  //   this.http.get('https://localhost:5001/api/members').subscribe({
  //     next: response => this.members.set(response),
  //     error: error => console.log(error),
  //     complete : () =>console.log('completed the htt prequest')
  //   })
  // }

   async ngOnInit() {
    this.members.set(await this.getMembers())
  }

  //Method with promise no need to subscribre (FirstValueFrom or  lastValueFrom)

  async getMembers(){
    try {
      return lastValueFrom(this.http.get('https://localhost:5001/api/members'));
    } catch (error) {
      console.log(error);
        throw error;
    }
  }
}

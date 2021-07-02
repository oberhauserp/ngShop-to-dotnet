import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs'; // OPTIONAL: Observables value-add
import { catchError, tap } from 'rxjs/operators';
import { Dog } from '../models/dog'; // OPTIONAL: Observables value-add.
import DOGS from '../dogdata.json';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DogsService {
  private dogData: Dog[] = DOGS;

  constructor(private httpClient: HttpClient) {
    const likes = localStorage.getItem('likes');
    if (!likes) {
      localStorage.setItem('likes', JSON.stringify([]));
    }
  }

  all(): Observable<Dog[]> {
    // return of(this.dogData);
    return this.httpClient.get<Dog[]>('https://localhost:5001/Dog').pipe(
      tap(data => {
        console.log('fetched dogs');
      }),
      catchError(this.handleError('get Dog', []))
    );
  }


  get(dogId: string): Observable<Dog> {
    // return this.dogData.filter(dog => dog.id === dogId);
    return this.httpClient.get<Dog>(`https://localhost:5001/Dog/` + dogId).pipe(
      tap(data => {
        console.log("Retrieved data for Dog number " + dogId);
      }),
      catchError(this.handleError('get Dog', new Dog()))
    );

  }


  getLikes(dogId): number {
    const likes = JSON.parse(localStorage.getItem('likes'));
    // tslint:disable-next-line:radix
    return parseInt(likes[dogId]);
  }


  update(dog): void {
    const likes = JSON.parse(localStorage.getItem('likes')) || localStorage.setItem('likes', JSON.stringify({}));
    likes[dog.id] = dog.likes;
    localStorage.setItem('likes', JSON.stringify(likes));
    // const editedCustomer = {id, ...customer};
    // return this.httpClient
    //   .put<Customer>(`http://127.0.0.1:3000/customers/${id}`, editedCustomer, {}).pipe(
    //     tap(_ => console.log('updated customer')),
    //     catchError(this.handleError('Update Customer', new Customer()))
    //   );
  }


  // addCustomer(customer: Customer): Observable<Customer> {
  //   console.log(customer);
  //   return this.httpClient
  //     .post<Customer>('http://127.0.0.1:3000/customers', customer, {}).pipe(
  //       tap(_ => console.log('added customer')),
  //       catchError(this.handleError('add Customer', new Customer()))
  //     );
  // }

  private handleError<T>(operation = 'operation', result ?: T) {
    return (error: any): Observable<T> => {
      console.log(error);
      console.log(`${operation} failed: ${error.message}`);

      return of(result as T);
    };
  }
}

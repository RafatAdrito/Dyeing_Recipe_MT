import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class DyeingRecipeService {
  readonly http = inject(HttpClient);
  getRecipe() {
    return firstValueFrom(this.http.get<any>('http://localhost:5247/recipes'));
  }
  saveRecipeData(data: any) {
    return firstValueFrom(
      this.http.post<any>('http://localhost:5247/recipes', data)
    );
  }

  deleteRecipeData(id: number) {
    return firstValueFrom(
      this.http.delete<any>(`http://localhost:5247/recipes/${id}`)
    );
  }

  getRecipeById(id: number) {
    return firstValueFrom(
      this.http.get<any>(`http://localhost:5247/recipes/${id}`)
    );
  }

  updateRecipeById(data: any, id: number) {
    return firstValueFrom(
      this.http.put<any>(`http://localhost:5247/recipes/${id}`, data)
    );
  }
}

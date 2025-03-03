import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PokemonGridComponent } from './pokemon-grid/pokemon-grid.component';
import { TrainerGridComponent } from './trainer-grid/trainer-grid.component';
import { TypesListComponent } from './types-list/types-list.component';
import { MovesGridComponent } from './moves-grid/moves-grid.component';

const routes: Routes = [
  { path: '', redirectTo: '/pokemon', pathMatch: 'full' },
  { path: 'pokemon', component: PokemonGridComponent },
  { path: 'trainer', component: TrainerGridComponent },
  { path: 'types', component:  TypesListComponent},
  { path: 'moves', component: MovesGridComponent },
  { path: '**', component: PokemonGridComponent },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

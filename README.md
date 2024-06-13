# Gamely

A game library manager connected to API, without ads

L'objectif du projet est de remplacer l'application *Stash* par une alternative Open source, sans publicité et se basant sur l'UI/UX des applications *Showly* et *Mihon*.

## Fonctionnalités attendues

- [ ] Rechercher des jeux par titre grace à l'API IGDB
- [ ] Afficher les détails d'un jeu
- [ ] Ajouter un jeu à sa bibliothèque (En cours, joué, voulu)
- [ ] Ajouter des tags aux jeux (100%, terminé, abandonné, infini...)
- [ ] Pouvoir noter des jeux (/10)
- [ ] Pouvoir mettre des jeux en favoris
- [ ] Recevoir une notification à la sortie de jeux ajoutés à sa bibliothèque
- [ ] Pouvoir renseigner le temps de jeu d'un jeu
- [ ] Pouvoir renseigner les plateformes sur lesquelles on a joué
- [ ] Pouvoir mettre un commentaire sur un jeu (uniquement en local, ce sont des notes personnelles)
- [ ] Avoir des statistiques sur sa bibliothèque (temps de jeu total, nombre de jeux terminés...)
- [ ] Possibilité d'exporter sa bibliothèque (et de l'importer)
- [ ] Voir les prochaines sorties par ordre chronologique
- [ ] Avoir les données d'HowLongToBeat pour chaque jeu
  - GET `https://howlongtobeat.com/?q={nom du jeu}` + Scrapping
- [ ] Avoir les données de CrackWatch pour chaque jeu (+ notifications)
  - GET `https://omycrack.com/searchscripts?q={nom du jeu}` + Scrapping
  - POST `https://gamestatus.info/back/api/gameinfo/game/search_title/` + body -> `{"title":"{nom du jeu}"}`
- [ ] Connaitre la date d'ajout d'un élément à la bibliothèque

## Todo

<!-- ### Archives -->
<!-- - Bloquer la rotation de l'écran -->
<!-- - Ajouter Dotween au projet -->
<!-- - Ajouter des animations à la barre de navigation (items actife/inactif, animation de masquage...) -->
<!-- - Créer le prefab d'une affiche de jeu pour la collection -->
<!-- - Créer les boutons de tri de la collection -->
<!-- - Ajouter des éléments dans la zone d'en-tête de la collection (Titre, Nombre d'éléments...) -->
<!-- - Ajouter gestion des clics sur les filtres de la collection -->
<!-- - Ajouter un scrollrect sur la grille de la collection -->
<!-- - Afficher la status bar Android -->
<!-- - Afficher la barre de navigation Android -->
<!-- - 120hz -->
<!-- - Ajouter un menu Settings -->
<!-- - Pouvoir changer de page avec la navbar. -->
<!-- - Ajouter un lien vers le github dans le menu Settings -->
<!-- - Ajouter le numéro de version de l'application dans le menu Settings -->
<!-- - Rendre les boutons des filtres plus gros -->
<!-- - Créer le préfab d'une fiche de jeu pour les détails -->
<!--    - Poster -->
<!--    - Date de sortie -->
<!--    - Description -->
<!--    - Studio -->
<!--    - Plateformes -->
<!--    - Genres -->
<!--    - Screenshot -->
<!--    - How long to beat -->
<!--    - Crackwatch -->
<!--    - Note Metacritic -->
<!--    - Recommendations -->
<!-- - Réduire la bordure sur la page des jeux -->
<!-- - Créer le visuel des pop up de bas de page -->
<!-- - Connecter l'API IGDB ou RAWG -->
<!-- - Permettre de rechercher des jeux -->
<!-- - Créer le visuel de la page Recherche -->

### Backlog

- Ajouter une option pour changer la couleur d'accentuation de l'application
- Ajouter une option pour changer la langue de l'application
- Ajouter une option pour rensiegner ses infos API IGDB
- Ajouter le nom des api utilisés dans les paramètres
- Optimiser les scrollrects de la collection (désactiver les éléments non visibles) (+ BatchRendererGroup)
- Supprimer le splashscreen Unity ([lien](https://github.com/kiraio-moe/USSR))
- Ajouter un fondu dans les changements des pages principales
- pouvoir ouvrir une autre page de jeu depuis la page d'un jeu
- Créer le visuel de la page Calendrier
- Faire le visuel de la PopUp pour noter un jeu
- Faire le visuel de la PopUp pour ajouter un jeu à la collection
- Faire scroll la page des jeux en haut quand on change de jeu
- Ajouter une icone sur le poster d'un jeu pour indiquer si le jeu est dans la collection
- Voir pour refaire les pages avec UI Toolkit
- Refaire l'animation des PopUp
- Grossir les filtres de la collection
- Mettre des jeux du moment sur la page "recherche"
- Ajouter des filtres à la recherche
- Mettre en place une base de données pour stocker les jeux
- Dimensioner correctement la backgroundPosterImage
- Corriger les problèmes de taille des textes sur les pages de détails
- Changer la couleur de la note en fonction de son niveau

### Next version

- Mettre la barre de recherche sur toutes les pages comme sur Showly
- Transformer l'icone de la barre de navigation en bouton X pour vider la recherche quand le texte n'est pas vide
- Générer les pages des détails des jeux au clic
  <!-- - Données textuelles -->
  <!-- - Données CrackWatch -->
  - Données HowLongToBeat
    - Si scrap trop complexe, faire un bouton pour arriver sur le site avec la recherche déjà faite
  <!-- - Poster -->
  - Screenshot
  - Jeux recommandés
  - Jeux de la même série
  
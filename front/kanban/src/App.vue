<script>

import axios from "axios";
export default {
  data() {
    return {
      board: null
    }
  },
  mounted: function () {
    window.myAppVue = this;
  },
  created() {
    this.getData();
  },
  methods: {
    formatDate(d) {
      return new Date(d).toLocaleDateString("pt-BR");
    },
    movCard(idQuadrant, idCard) {
      console.log(idQuadrant)
      axios.post('https://localhost:44367/api/Board/MovCard', {
        IdQuadrant: idQuadrant,
        IdCard: idCard
      })
        .then(function (response) {
          console.log(response);
        })
        .catch(function (error) {
          console.log(error);
        });
    },
    filter: function (event) {
      let txt = event.srcElement;
      axios
        .get("https://localhost:44367/api/Board/FiltraBoard/1/" + txt.value)
        .then((res) => {
          this.board = res.data;
          console.log(this.board);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    getData() {
      axios
        .get("https://localhost:44367/api/Board/GetBoard/1")
        .then((res) => {
          this.board = res.data;
          console.log(this.board);
        })
        .catch((error) => {
          console.log(error);
        });
    },

  },
};
</script>

<template>
  <table border="0">
    <tr>
      <td class="barra">
        <table border="0">
          <tr>
            <td>
              <img src="img/logo.png" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/bullseye-arrow.png" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/calendar-clock.png" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/file-chart-outline.png" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/material-access-time.svg" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/icone-cadastrar.png" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/icone-calendario-pequeno.png" />
            </td>
          </tr>
          <tr>
            <td>
              <img src="img/icone-notificacao.png" />
            </td>
          </tr>
        </table>

      </td>
      <td>
        <table border="0">
          <tr>
            <td>
              Tarefas
            </td>
            <td>
              <input type="text" id="txtFiltro" placeholder="Pesquisar por Tarefa" v-on:change="filter" />
            </td>
            <td>
              Filtro
            </td>
          </tr>
        </table>
        <br />
        <div style="display: flex;">
          <div v-for="quadrant in board.quadrants" style="padding-right: 20px;">
            <div class="sectionBack" :id="'quad_' + quadrant.id" ondrop="drop(event)" ondragover="allowDrop(event)">
              <h5 class="sectionHeader">{{ quadrant.name }}</h5>
              <div v-for="card in quadrant.cards" :id="'card_' + card.id" class="card" ondragstart="drag(event)"
                style="border:1px red solid;background-color: white;" draggable="true">
                <div style="width: 100%;">
                  <table border="0" width="100%">
                    <tr>
                      <td>
                        <table border="0" width="100%">
                          <tr>
                            <td> <span class="rectangle1">{{ card.squad.name }}</span>
                            </td>
                            <td style="text-align: right;" class="fontSmall">
                              Código<br />#{{ card.id }}
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <span class="name">{{ card.name }}</span>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <table border="0" width="100%">
                          <tr>
                            <td>
                              <table border="0" width="100%">
                                <tr>
                                  <td>
                                    <span class="fontSmall">Projeto</span>
                                  </td>
                                </tr>
                                <tr>
                                  <td>
                                    <span class="projectName">{{ board.project.name }}</span>
                                  </td>
                                </tr>
                              </table>
                            </td>
                            <td style="text-align: right;">
                              <table border="0" width="100%">
                                <tr>
                                  <td>
                                    <span class="fontSmall">Prevista</span>
                                  </td>
                                </tr>
                                <tr>
                                  <td>
                                    <img src="img/icone-calendario-pequeno.svg" /> <span class="projectName">{{
                                      formatDate(card.prevision) }}</span>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                    <tr>
                      <td>
                        <table border="0" width="100%">
                          <tr>
                            <td class="fontSmall">
                              Descrição
                            </td>
                          </tr>
                          <tr>
                            <td class="description">
                              {{ card.description }}
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>

                    <tr>
                      <td class="fontSmall">Acompanhamento</td>
                    </tr>

                    <tr>
                      <td>
                        <table border="0" width="100%">
                          <tr>
                            <td>
                              <table border="0" width="100%">
                                <tr>
                                  <td>
                                    <table border="0" width="100%">
                                      <tr>
                                        <td>
                                          <img src="img/material-access-time.svg" />
                                        </td>
                                        <td>
                                          <table border="0" width="100%">
                                            <tr class="fontSmall">
                                              <td>Previsto</td>
                                            </tr>
                                            <tr>
                                              <td>{{ card.effort }}</td>
                                            </tr>
                                          </table>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                  <td style="text-align: right;">
                                    <div class="rectangle2">{{ card.status }}</div>
                                  </td>
                                </tr>
                                <tr>
                                  <td>
                                    <table border="0" width="100%">
                                      <tr>
                                        <td>
                                          <img src="img/material-access-time.svg" />
                                        </td>
                                        <td>
                                          <table border="0" width="100%">
                                            <tr>
                                              <td class="fontSmall">Saldo <br />
                                                <div class="rectangle3">{{ card.balance }}</div>
                                              </td>
                                              <td class="fontSmall" style="text-align: right;">Equipe <br />
                                                <span v-for="resouce in card.squad.resources" class="circulo">{{
                                                  resouce.acronym
                                                }}</span>
                                              </td>
                                            </tr>
                                          </table>
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </td>
    </tr>
  </table>
</template>
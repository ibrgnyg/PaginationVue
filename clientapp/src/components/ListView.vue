<template>
	<div class="page-content page-container">
		<h2 class="text-center">USERS</h2>
		<div class="album py-5 bg-light">
			<div class="container">
				<div class="row">
					<div class="col-md-4" v-for="ListUser in PaginateList">
						<div class="card mb-4 box-shadow post-cards">
							<div class="card-body">

								<router-link :to="{name:'Details', params: {id:ListUser.id}}">
									<div class="text-center">

										<div><a data-abc="true"><span class="w-48 avatar gd-warning"><img v-bind:src="ListUser.image" /></span></a></div>

										<div class="flex">
											<a class="item-author text-color" data-abc="true" style="color:black">
												{{ListUser.name}}
											</a>
											<div class="item-except text-muted text-sm h-1x">
												{{ListUser.lastName}}
											</div>
										</div>
									</div>
								</router-link>
							</div>
						</div>
					</div>
				</div>
				<div class="text-center">
					<h4>Current Page/<small> {{page}}</small></h4>
				</div>
				
			</div>
		</div>
		<br />
		<div class="text-center">
			<button type="button" class="btn btn-info" v-if="page != 1" v-on:click="page--"> Previous </button>
			<!--<button type="button" class="btn  btn-info" v-for="pageNumber in pages.slice(page-1, page+5)" v-on:click="page = pageNumber"> {{pageNumber}} </button>-->
			<button type="button" @click="page++" v-if="page < pages.length" class="btn btn-info"> Next </button>
		</div>
	</div>

</template>

<script>
	import axios from 'axios';
	export default {
		name: "ListView",
		data() {
			return {
				ApiUrl: "/api/user",
				ListUser: [],
				page: 1,
				perPage: 12,
				pages: [],
			}
		},
		methods: {
			List() {
				axios.get(this.ApiUrl)
					.then(response => {
						this.ListUser = response.data;
					})
					.catch(function() {
						alert("users could not load!!")
					});
			},
			setPages() {
				let numberOfPages = Math.ceil(this.ListUser.length / this.perPage);
				for (let index = 1; index <= numberOfPages; index++) {
					this.pages.push(index);
				}
			},
			paginate(ListUser) {
				var page = this.page;
				var perPage = this.perPage;
				var PU = (page * perPage) - perPage;
				var TUP = (page * perPage);
				return ListUser.slice(PU, TUP);
			}
		},
		computed: {
			PaginateList() {
				return this.paginate(this.ListUser);
			}
		},
		watch: {
			ListUser() {
				this.setPages();
			}
		},
		mounted() {
			this.List();
		},
		
	}
</script>


<!--List  template	css-->
<style>

	.bg-light{
		background-color:orangered!important;
		border-radius:25px;
		height:718px;
	}
	





	.text-muted {
		color: #99a0ac !important
	}

	.block,
	.card {
		background: #fff;
		border-width: 0;
		border-radius: .25rem;
		box-shadow: 0 1px 3px rgba(0, 0, 0, .05);
		margin-bottom: 1.5rem
	}

	.avatar {
		position: relative;
		line-height: 1;
		border-radius: 500px;
		white-space: nowrap;
		font-weight: 700;
		border-radius: 100%;
		display: -ms-flexbox;
		display: flex;
		-ms-flex-pack: center;
		justify-content: center;
		-ms-flex-align: center;
		align-items: center;
		-ms-flex-negative: 0;
		flex-shrink: 0;
		border-radius: 500px;
		box-shadow: 0 5px 10px 0 rgba(50, 50, 50, .15)
	}

		.avatar img {
			border-radius: inherit;
			width: 100%
		}

	.gd-primary {
		color: #fff;
		border: none;
		background: #448bff linear-gradient(45deg, #448bff, #44e9ff)
	}

	.gd-success {
		color: #fff;
		border: none;
		background: #31c971 linear-gradient(45deg, #31c971, #3dc931)
	}

	.gd-info {
		color: #fff;
		border: none;
		background: #14bae4 linear-gradient(45deg, #14bae4, #14e4a6)
	}

	.gd-warning {
		color: #fff;
		border: none;
		background: #f4c414 linear-gradient(45deg, #f4c414, #f45414)
	}

	@media (min-width:992px) {
		.page-container {
			max-width: 1140px;
			margin: 0 auto
		}

		.page-sidenav {
			display: block !important
		}
	}

	.list {
		padding-left: 0;
		padding-right: 0
	}

	.list-item {
		position: relative;
		display: -ms-flexbox;
		display: flex;
		-ms-flex-direction: column;
		flex-direction: column;
		min-width: 0;
		word-wrap: break-word
	}

	.list-row .list-item {
		-ms-flex-direction: row;
		flex-direction: row;
		-ms-flex-align: center;
		align-items: center;
		padding: .75rem .625rem
	}

		.list-row .list-item > * {
			padding-left: .625rem;
			padding-right: .625rem
		}

	.no-wrap {
		white-space: nowrap
	}

	.text-color {
		color: #5e676f
	}

	.text-gd {
		-webkit-background-clip: text;
		-moz-background-clip: text;
		background-clip: text;
		-webkit-text-fill-color: transparent;
		-moz-text-fill-color: transparent;
		text-fill-color: transparent
	}

	.text-sm {
		font-size: .825rem
	}

	.h-1x {
		height: 1.25rem;
		overflow: hidden;
		display: -webkit-box;
		-webkit-line-clamp: 1;
		-webkit-box-orient: vertical
	}

	.w-48 {
		width: 48px !important;
		height: 48px !important
	}

	a:link {
		text-decoration: none
	}
</style>


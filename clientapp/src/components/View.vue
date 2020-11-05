<template>
	<div>
		
		<div class="content">
			<div class="container">
				<div class="row">
					<div class="float-left">
						<div class="col-sm-4"><a @click="backBtn" class="btn btn-custom waves-effect waves-light mb-4" data-animation="fadein" data-plugin="custommodal" data-overlayspeed="200" data-overlaycolor="#36404a"><i class="fas fa-chevron-left" style="font-size:30px;color:black"></i></a></div>
					</div>
				</div>
				<div class="row">
					<div class="col-lg-4">
						
						<div class="text-center card-box">
							<div class="member-card pt-2 pb-2">
								<div class="text-center">
									<div><a data-abc="true"><span class="w-48 avatar gd-warning"><img v-bind:src="content.image" /></span></a></div>
								</div>
							
								<div class="">
									<h4>{{content.name}}</h4>
									<p class="text-muted">last name | {{content.lastName}}</p>
								</div>
								<div>
									Email | <span><a class="text-pink">{{content.email}}</a></span>
								</div>
								<br />
								<div>
									<h5>Phone</h5>
									{{content.phone}}
								</div>
								<h5>City code</h5>
								{{content.cityCode}}
								<div class="mt-4">
									<div class="row">
										<div class="col-4">
											<div class="mt-3">
												<h4>City</h4>
												<p class="mb-0 text-muted">{{content.city}}</p>
											</div>
										</div>
										<div class="col-4">
											<div class="mt-3">
												<h4>DOB</h4>
												<p class="mb-0 text-muted">{{content.dateOfBirth | moment}}</p>
											</div>
										</div>
										<div class="col-4">
											<div class="mt-3" v-if="content.gender > 0">
												<h4>Gender</h4>
												<p class="mb-0 text-muted">Male</p>
											</div>
											<div class="mt-3" v-else="content.gender">
												<h4>Gender</h4>
												<p class="mb-0 text-muted">Female</p>
											</div>
										</div>
									</div>
								
								</div>
							</div>
						</div>
					</div>
					
				</div>
				
			</div>

		</div>
	</div>
</template>

<script>
	import axios from 'axios';
	import moment from 'moment';
	export default {
		name:"View",
		data() {
			return {
				id: null,
				content: null,
			}
		},
		methods: {
			backBtn() {
				this.$router.push({ path: "/list" });
			}
		},
		mounted() {
			axios.get("/api/user/" + this.$route.params.id).then((res) => {
				this.content = res.data;
			})
		},
		filters: {
			moment: function (date) {
				return moment(date).format('DD/M/YYYY');
			},
		},
	}
</script>
<!-- Card Page css-->

<style>
	.text{
		margin-top:70px;
		margin-left:450px;
	}

	body {
		background: #DCDCDC!important;
		margin-top: 20px;
	}

	.card-box {
		padding: 20px;
		border-radius: 3px;
		margin-bottom: 30px;
		background-color: #fff;
	}

	.social-links li a {
		border-radius: 50%;
		color: rgba(121, 121, 121, .8);
		display: inline-block;
		height: 30px;
		line-height: 27px;
		border: 2px solid rgba(121, 121, 121, .5);
		text-align: center;
		width: 30px
	}

		

	.thumb-lg {
		height: 88px;
		width: 88px;
	}

	.img-thumbnail {
		padding: .25rem;
		background-color: #fff;
		border: 1px solid #dee2e6;
		border-radius: .25rem;
		max-width: 100%;
		height: auto;
	}

	.text-pink {
		color: #ff679b !important;
	}

	.btn-rounded {
		border-radius: 2em;
	}

	.text-muted {
		color: #98a6ad !important;
	}

	h4 {
		line-height: 22px;
		font-size: 18px;
	}
</style>
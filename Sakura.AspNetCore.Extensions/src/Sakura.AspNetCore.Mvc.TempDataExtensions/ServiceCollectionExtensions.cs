﻿using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sakura.AspNetCore.Mvc;

// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	///     Provide extension methods for service configurations. This class is static.
	/// </summary>
	public static class ServiceCollectionExtensions
	{
		/// <summary>
		///     Set <see cref="EnhancedSessionStateTempDataProvider" /> as the default <see cref="ITempDataProvider" /> service
		///     implementation.
		/// </summary>
		/// <param name="services">The service container to adding the service.</param>
		/// <exception cref="ArgumentNullException"><paramref name="services" /> is <c>null</c>.</exception>
		[PublicAPI]
		public static IServiceCollection AddEnhancedTempData([NotNull] this IServiceCollection services)
		{
			// Argument check
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			// Add the IObjectSerializer implementation
			services.TryAddSingleton<IObjectSerializer, JsonObjectSerializer>();

			// Replace default ITempDataProvider
			services.Replace(new ServiceDescriptor(typeof(ITempDataProvider), typeof(EnhancedSessionStateTempDataProvider),
				ServiceLifetime.Singleton));

			return services;
		}
	}
}